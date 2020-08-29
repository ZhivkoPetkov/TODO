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

const getTasks = async function (filter) {
    try {
        const response = await axios.get(`${API}/tasks`)
        const data = parseList(response);
        if (filter) {
            if (filter === 'today') {
                let current_datetime = new Date().toLocaleDateString("en-US");
                return data.filter(p => new Date(p.endDate).toLocaleDateString("en-US") === current_datetime)
            } else if (filter === 'important') {
                return data.filter(p => p.isImportant);
            }
            else {
                return data.filter(p => p.category.name === filter);
            }
        }
        return data;
    } catch (error) {
        console.log(error.message);
        return [];
    }
};

const addTask = async function (task) {

    const response = await axios.post(`${API}/tasks`, {
        title: task.title,
        categoryid: task.category,
        enddate: task.enddate,
        isimportant: task.isimportant,
    });
    return response.data;
};

const deleteTask = async function (id) {
    const response = await axios.delete(`${API}/tasks/` + id);
    console.log(response.data);
    return response.data;
};

const finishTask = async function (id) {
    const response = await axios.post(`${API}/tasks/finish/` + id);
    console.log(response.data);
    return response.data;
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
    getCategories,
    getTasks,
    addTask,
    deleteTask,
    finishTask
};