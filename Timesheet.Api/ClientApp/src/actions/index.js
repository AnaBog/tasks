export const GET_CLIENTS = 'GET_CLIENTS';
export const DELETE_CLIENT = 'DELETE_CLIENT';
export const UPDATE_CLIENT = 'UPDATE_CLIENT';

export const getClients = (clients) => ({
    type: GET_CLIENTS,
    clients: clients
})

export const onGetClients = (payload) => {
    return dispatch => {
        dispatch(getClients(payload))
    }
}

export const deleteClient = (clientId) => ({
    type: DELETE_CLIENT,
    clientId: clientId
})


export const onDeleteClient = (payload) => {
    return dispatch => {
        dispatch(deleteClient(payload))
    }
}

export const updateClient = (client) => ({
    type: UPDATE_CLIENT,
    client: client
}
    )

export const onUpdateClient = (payload) => {
    return dispatch => {
        dispatch(updateClient(payload))
    }
}