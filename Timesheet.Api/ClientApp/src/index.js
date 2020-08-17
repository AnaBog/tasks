import React from 'react'
import axios from 'axios'
import { render } from 'react-dom'
import { Provider } from 'react-redux'
import { createStore, applyMiddleware, compose } from 'redux';
import App from './components/App'
import rootReducer from './reducers'
import thunk from 'redux-thunk';

const logger = store => {
    return next => {
        return action => {
            console.log('[Middleware] Dispatching', action);
            const result = next(action);
            console.log('[Middleware] next state', store.getState());
            return result;
        }
    }
};

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const store = createStore(rootReducer, composeEnhancers(applyMiddleware(logger, thunk)))

axios.defaults.baseURL = 'https://localhost:44327/api/'

render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById('root')
)