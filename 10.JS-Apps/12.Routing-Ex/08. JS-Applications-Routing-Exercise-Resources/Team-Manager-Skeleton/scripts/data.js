function host(endpoint) {
    return `https://api.backendless.com/52906EF8-B557-030D-FF90-71A830A0D500/278AAD7F-FFC7-495B-A2B4-6F45F230E8FF/${endpoint}`;
}

const endpoints = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    TEAMS: 'data/teams',
    UPDATE_USER: 'users/',
    LOGOUT: 'users/logout'
};

export async function register(username, password) {
    return (await fetch(host(endpoints.REGISTER), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username,
            password
        })
    })).json();
}

export async function login(username, password) {
    return (await fetch(host(endpoints.LOGIN), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            login: username,
            password
        })
    })).json();
}

export async function logout() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        throw new Error('User is not logged in!');
    }

    return fetch(host(endpoints.LOGOUT), {
        method: 'GET',
        headers: {
            'user-token': token
        }
    });
}

async function setUserTeamId(userId, teamId) {
    const token = localStorage.getItem('userToken');
    if (!token) {
        throw new Error('User is not logged in!');
    }

    return (await fetch(host(endpoints.UPDATE_USER + userId + '/teamId'), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify([teamId])
    })).json();
}

export async function createTeam(team) {
    const token = localStorage.getItem('userToken');
    if (!token) {
        throw new Error('User is not logged in!');
    }

    const result = await (await fetch(host(endpoints.TEAMS), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(team)
    })).json();

    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }

    const userUpdataResult = await setUserTeamId(result.ownerId, result.objectId);

    if (userUpdataResult.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, userUpdataResult);
        throw error;
    }

    return result;
}

export async function getTeamById(id) {
    return (await fetch(host(endpoint.TEAMS + '/' + id))).json();
}

export async function getTeams() {
    return (await fetch(host(endpoint.TEAMS))).json();
}