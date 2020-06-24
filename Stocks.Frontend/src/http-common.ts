import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:5001/api",
  headers: {
    "Content-type": "application/x-www-form-urlencoded",
    "Access-Control-Allow-Origin": "*"
  }
});