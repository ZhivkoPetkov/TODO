import * as axios from 'axios';
import { API } from '../config';

const getCategories = async function () {
    try {
        const response = await axios.get(`${API}/categories`)
        const data = parseList(response);
        return data;
    } catch (error) {
        console.log(error.message);
        return [];
    }
};

export const parseItem = (response, code) => {
    if (response.status !== code) throw Error(response.message);
    let item = response.data;
    if (typeof item !== 'object') {
        item = undefined;
    }
    return item;
};

const parseList = response => {
    if (response.status !== 200) throw Error(response.message);
    if (!response.data) return [];
    let list = response.data;
    if (typeof list !== 'object') {
        list = [];
    }
    return list;
};

export const dataservice = {
    getCategories
};