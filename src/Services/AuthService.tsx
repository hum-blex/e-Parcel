// import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";

// This will be replaced with actual API URL later
// const api = "http://localhost:5167/api/";

export const loginAPI = async (email: string, password: string) => {
  try {
    //  returning a mock response
    const mockResponse: UserProfileToken = {
      firstName: "John",
      lastName: "Doe",
      email: email,
      token: "mock-token-1234567890",
    };
    return { data: mockResponse };

    // Later, when  backend is ready,  use this:
    // const data = await axios.post<UserProfileToken>(api + "account/login", {
    //   email: email,
    //   password: password,
    // });
    // return data;
  } catch (error) {
    handleError(error);
  }
};

export const signUpAPI = async (
  firstName: string,
  lastName: string,
  email: string,
  password: string
) => {
  try {
    //  returning a mock response
    const mockResponse: UserProfileToken = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      token: "mock-token-0987654321",
    };
    return { data: mockResponse };

    // Later, when  backend is ready,  use this:
    // const data = await axios.post<UserProfileToken>(api + "account/register", {
    //   firstName: firstName,
    //   lastName: lastName,
    //   email: email,
    //   password: password,
    // });
    // return data;
  } catch (error) {
    handleError(error);
  }
};