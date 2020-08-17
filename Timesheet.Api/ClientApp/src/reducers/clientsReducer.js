import * as actionTypes from '../actions/';

const initialState = {
    clients: null
};

const clientsActions = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.GET_CLIENTS:
            return {
                ...state,
                clients: action.clients
            }

        case actionTypes.DELETE_CLIENT:
            const filteredClients = {
                ...state,
                clients: state.clients.filter(c => c.id !== action.clientId)
            }
            return filteredClients;

        case actionTypes.UPDATE_CLIENT:
            const copiedState = { ...state };

            for (let i in copiedState.clients) {
                if (copiedState.clients[i].id === action.client.id) {
                    copiedState.clients[i] = action.client;
                    break;
                }
            }

            return copiedState;

        default:
            return state;
    }
}

export default clientsActions;