import { combineReducers } from 'redux'
import clientsReducer from './clientsReducer'
import timesheetReducer from './timesheetReducer'

export default combineReducers({
    clientsReducer,
    timesheetReducer
})
