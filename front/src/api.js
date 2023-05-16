
import axios from 'axios';
import store from './store'

const api = "http://localhost:3000";
// async function LOGIN(login, password) {
//   try {
//     const response = await axios.get(`${api}/user/`, { params: {offset, actual, city}, headers: { authorization: token } });
//     return response.data;
//   } catch (error) {
//     console.error(error);
//     return null;
//   }
// }

// async function LOGIN(login, password) {
//   if (!store.state?.user?.access_token) return;
//   try {
//     const response = await axios.post(`${api}/api/wards/`, { game, offset }, { headers: { authorization: token } });
//     return response.data;
//   } catch (error) {
//     console.error(error);
//     return null;
//   }
// }
async function LOGIN(login, password) {
  try {
    const response = await axios.post(`${api}/user/login/`, { login, password });
    return response.data || true;
  } catch (error) {
    if(error.code == "ERR_NETWORK")  { console.error(error); return null; };
    return false;
  }
}
async function REGISTER(data) {
  try {
    const response = await axios.post(`${api}/user/register/`, data);
    return response.data|| true;;
  } catch (error) {
    if(error.code == "ERR_NETWORK")  {  console.error(error); return null;};
    return error?.response?.data || false;
  }
}

async function ME() {
  try {
    const response = await axios.get(`${api}/user/me`, { headers: { authorization: store.state.access_token } });
    return response.data;
    } catch (error) {
        if(error.code == "ERR_NETWORK")  {console.error(error); return null; };
        return false;
    }
}

async function COALS() {
  try {
    const response = await axios.get(`${api}/coals`, { headers: { authorization: store.state.access_token } });
    return response.data;
    } catch (error) {
        if(error.code == "ERR_NETWORK")  {console.error(error); return null; };
        return false;
    }
}
async function SUPPLIERS() {
  try {
    const response = await axios.get(`${api}/suppliers`, { headers: { authorization: store.state.access_token } });
    return response.data;
    } catch (error) {
        if(error.code == "ERR_NETWORK")  {console.error(error); return null; };
        return false;
    }
}

export default {
  rest: {
    LOGIN, ME, REGISTER,COALS,SUPPLIERS
  },
}