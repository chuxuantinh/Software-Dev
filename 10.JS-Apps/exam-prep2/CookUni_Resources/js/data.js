import { beginRequest, endRequest, showError } from './notification.js';
import API from './api.js';

const endpoints = {
    RECIPES: 'data/recipes',
    RECIPE_BY_ID: 'data/recipes/'
};

const api = new API(
    'A03F19B4-3F89-5BA1-FF5E-DCE4AB95F300',
    '337B4A79-3BC5-41B5-8F61-830DEAFA4E81',
    beginRequest,
    endRequest
);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function getAll() {
    return api.get(endpoints.RECIPES);
}

export async function createRecipe(recipe) {
    return api.post(endpoints.RECIPES, recipe);
}

export async function getRecipeById(id) {
    return api.get(endpoints.RECIPE_BY_ID + id);
}

export async function editRecipe(id, recipe) {
    return api.put(endpoints.RECIPE_BY_ID + id, recipe);
}

export async function deleteRecipe(id) {
    return api.delete(endpoints.RECIPE_BY_ID + id);
}

export async function likeRecipe(id) {
    const recipe = await getRecipeById(id);
    return editRecipe(id, { likes: recipe.likes + 1 });
}

export function checkResult(result) {
    if(result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }
}