import { beginRequest, endRequest, showError } from './notification.js';
import API from './api.js';

const endpoints = {
    MOVIES: 'data/movies',
    MOVIE_BY_ID: 'data/movies/'
};

const api = new API(
    '6E45D00C-101E-5BF9-FF2C-B81247B4DD00',
    '58BC7FA0-B5E4-41B8-B687-679E1059FB9A',
    beginRequest,
    endRequest);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

// get all movies
export async function getMovies(search) {
    if (!search) {
        return api.get(endpoints.MOVIES); // endpoints.MOVIES + '?pageSize=10&offset=0'
    } else {
        return api.get(endpoints.MOVIES + `?where=${escape(`genres LIKE '%${search}%'`)}`);
    }
}

// get movie by ID
export async function getMovieById(id) {
    return api.get(endpoints.MOVIE_BY_ID + id);
}

// create movie
export async function createMovie(movie) {
    return api.post(endpoints.MOVIES, movie);
}

// edit movie
export async function updateMovie(id, updatedProps) {
    return api.put(endpoints.MOVIE_BY_ID + id, updatedProps);
}

// delete movie
export async function deleteMovie(id) {
    return api.delete(endpoints.MOVIE_BY_ID + id);
}

// get movies by user ID
export async function getMovieByOwner() {
    const ownerId = localStorage.getItem('userId');
    return api.get(endpoints.MOVIES + `?where=ownerId%3D%27${ownerId}%27`);
}

// buy ticket
export async function buyTicket(movie) {
    const newTickets = movie.tickets - 1;
    const movieId = movie.objectId;

    return updateMovie(movieId, { tickets: newTickets });
}