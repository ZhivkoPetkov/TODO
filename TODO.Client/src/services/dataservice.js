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

const getTasks = async function () {
    try {
        const response = await axios.get(`${API}/tasks`)
        const data = parseList(response);
        return data;
    } catch (error) {
        console.log(error.message);
        return [];
    }
};

const addTask = async function (task) {
        console.log(task.title);
        const response = await axios.post(`${API}/tasks`, {
            title: task.title,
            categoryid: task.category,
            enddate: task.enddate,
            isimportant: task.isimportant
            
        }).then(function (response) {
            console.log(response);
            return response;
          })
          .catch(function (error) {
            console.log(error.message);
          })
}

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
    getCategories,
    getTasks,
    addTask
};