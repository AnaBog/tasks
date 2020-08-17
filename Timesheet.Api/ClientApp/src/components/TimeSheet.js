import * as React from 'react'
import { connect } from 'react-redux'
import Axios from 'axios';

class TimeSheet extends React.Component {

	state = {
		date: new Date(),
		months: [
			"January",
			"February",
			"March",
			"April",
			"May",
			"June",
			"July",
			"August",
			"September",
			"October",
			"November",
			"December",
		],
		days: []
	}

	componentDidMount() {
		this.calculateDays();
	}

	calculateDays = () => {
		this.state.date.setDate(1);

		const lastDay = new Date(
			this.state.date.getFullYear(),
			this.state.date.getMonth() + 1,
			0
		).getDate();

		const prevLastDay = new Date(
			this.state.date.getFullYear(),
			this.state.date.getMonth(),
			0
		).getDate();

		const firstDayIndex = this.state.date.getDay();

		const lastDayIndex = new Date(
			this.state.date.getFullYear(),
			this.state.date.getMonth() + 1,
			0
		).getDay();

		const nextDays = 7 - lastDayIndex - 1;

		console.log('date: ', this.state.date)
		console.log('lastDay: ', lastDay)
		console.log('prevLastDay: ', prevLastDay)
		console.log('firstDayIndex: ', firstDayIndex)
		console.log('lastDayIndex: ', lastDayIndex)
		console.log('nextDays: ', nextDays)

		Axios.get('timesheets/range', {
			params: this.convertFromToDate(firstDayIndex, prevLastDay, lastDay, nextDays)
		}).then((response) => {
			let days = [];
			let timesheet = response.data;

			for (let x = firstDayIndex; x > 0; x--) {
				const dayDate = this.convertDate(prevLastDay - x + 1, this.state.date.getMonth(), this.state.date.getFullYear());
				const dailyTS = timesheet.find(t => t.date.includes(dayDate));

				days.push(<div key={`prev-${x}`} className={`prev-date ${this.getStatusClass(dailyTS)}`}>
					<span className="date">{prevLastDay - x + 1}</span>
					<span className="hours">Hours: {dailyTS ? dailyTS.totalHoursPerDay : '0'}</span>
				</div>);
			}

			for (let i = 1; i <= lastDay; i++) {
				const dayDate = this.convertDate(i, this.state.date.getMonth() + 1, this.state.date.getFullYear());
				const dailyTS = timesheet.find(t => t.date.includes(dayDate));

				if (i === new Date().getDate() && this.state.date.getMonth() === new Date().getMonth()) {
					days.push(<div key={i} className={`today ${this.getStatusClass(dailyTS)}`}>
						<span className="date">{i}</span>
						<span className="hours">Hours: {dailyTS ? dailyTS.totalHoursPerDay : '0'}</span>
					</div>);
				} else {
					days.push(<div key={i} className={`${this.getStatusClass(dailyTS)}`}>
						<span className="date">{i}</span>
						<span className="hours">Hours: {dailyTS ? dailyTS.totalHoursPerDay : '0'}</span>
					</div>);
				}
			}

			for (let j = 1; j <= nextDays; j++) {
				const dayDate = this.convertDate(j, this.state.date.getMonth() + 2, this.state.date.getFullYear());
				const dailyTS = timesheet.find(t => t.date.includes(dayDate))

				days.push(<div key={`next-${j}`} className={`next-date ${this.getStatusClass(dailyTS)}`}>
					<span className="date">{j}</span>
					<span className="hours" >Hours: {dailyTS ? dailyTS.totalHoursPerDay : '0'}</span>
				</div>);
			}

			this.setState({
				days: days
			})

		});
	};

	convertDate(day, month, year) {
		return `${month}/${day}/${year}`;
	}

	getStatusClass(dailyTS) {
		let hClass = '';
		if (dailyTS) {
			if (dailyTS.totalHoursPerDay > 0 && dailyTS.totalHoursPerDay < 7.5) {
				hClass = 'negative';
			}
			if (dailyTS.totalHoursPerDay >= 7.5) {
				hClass = 'positive';
			}
		}
		return hClass;
	}

	convertFromToDate(firstDayIndex, prevLastDay, lastDay, nextDays) {
		const fromDay = firstDayIndex === 0 ? 1 : prevLastDay - firstDayIndex + 1;
		const toDay = nextDays === 0 ? lastDay : nextDays;

		const fromMonth = firstDayIndex === 0 ? this.state.date.getMonth() + 1 : this.state.date.getMonth();
		const toMonth = nextDays === 0 ? this.state.date.getMonth() + 1 : this.state.date.getMonth() + 2;

		const year = this.state.date.getFullYear();

		return {
			from: `${fromMonth}/${fromDay}/${year}`,
			to: `${toMonth}/${toDay}/${year}`
		}
	}

	onPrevMonth = () => {
		this.setState({
			date: new Date(this.state.date.setMonth(this.state.date.getMonth() - 1))
		}, () => {
			this.calculateDays();
		}) 
	}

	onNextMonth = () => {
		this.setState({
			date: new Date(this.state.date.setMonth(this.state.date.getMonth() + 1))
		}, () => {
			this.calculateDays();
		}) 
	}

	render() {
        return (
			<div className="wrapper">
				<section className="content">
					<div className="calendar">
						<div className="grey-box-wrap">
							<div className="top">
								<a className="prev" onClick={() => this.onPrevMonth()}>
									<i className="zmdi zmdi-chevron-left"></i> previous month
								</a>
								<span className="center">{`${this.state.months[this.state.date.getMonth()]}, ${this.state.date.getFullYear()}`}</span>
								<a className="next" onClick={() => this.onNextMonth()}>
									next month <i class="zmdi zmdi-chevron-right"></i>
								</a>
							</div>
							<div className="bottom"></div>
						</div>
						<div className="month-table">
							{
								this.state.days
							}
						</div>
						<div className="total">
							<span>Total hours: <em>90</em></span>
						</div>
					</div>
				</section>
			</div>
        )
    }
}

export default connect()(TimeSheet);
