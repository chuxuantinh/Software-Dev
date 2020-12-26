import { beginRequest, endRequest, showError } from './notification.js';
import API from './api.js';

const endpoints = {
    MOVIES: 'data/movies',
    MOVIE_BY_ID: 'data/movies/'
};

const api = new API(
    '4B096C0D-C7DA-7DB6-FF94-1B46F983CA00',
    'CEA6C249-8285-42BC-B69C-5C303E70E52E',
    // beginRequest,
    // endRequest
);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function getAll(search) {
    if (!search) {
        return api.get(endpoints.MOVIES); // endpoints.MOVIES + '?pageSize=10&offset=0'
    } else {
        return api.get(endpoints.MOVIES + `?where=${escape(`title LIKE '%${search}%'`)}`);
    }
}

export async function createMovie(movie) {
    return api.post(endpoints.MOVIES, movie);
}

export async function getMovieById(id) {
    return api.get(endpoints.MOVIE_BY_ID + id);
}

export async function editMovie(id, movie) {
    return api.put(endpoints.MOVIE_BY_ID + id, movie);
}

export async function deleteMovie(id) {
    return api.delete(endpoints.MOVIE_BY_ID + id);
}

export async function likeMovie(id) {
    const movie = await getMovieById(id);
    return editMovie(id, { likes: movie.likes + 1 });
}

export function checkResult(result) {
    if(result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }
}