import * as actionTypes from '../actions/';

const initialState = {
    timesheet: null
};

const timesheetReducer = (state = initialState, action) => {
    switch (action.type) {
        default:
            return state;
    }
}

export default timesheetReducer;