import { createContext, useEffect, useState } from "react";
import { UserProfileToken } from "../Models/User";
import { useNavigate } from "react-router-dom";
import { loginAPI, signUpAPI } from "../Services/AuthService";
import { toast } from "react-toastify";
import React from "react";

type UserContextType = {
  user: UserProfileToken | null;
  token: string | null;
  signUp: (firstName: string, lastName: string, email: string, password: string) => void;
  login: (email: string, password: string) => void;
  logout: () => void;
  isLoggedIn: () => boolean;
};

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
  const navigate = useNavigate();
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserProfileToken | null>(null);
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    const userJson = localStorage.getItem("user");
    const token = localStorage.getItem("token");
    if (userJson && token) {
      const userObj = JSON.parse(userJson) as UserProfileToken;
      setUser(userObj);
      setToken(token);
      // axios.defaults.headers.common["Authorization"] = "Bearer " + token;
    }
    setIsReady(true);
  }, []);

  const signUp = async (
    firstName: string,
    lastName: string,
    email: string,
    password: string
  ) => {
    const res = await signUpAPI(firstName, lastName, email, password);
    if (res && res.data) {
      localStorage.setItem("token", res.data.token);
      localStorage.setItem("user", JSON.stringify(res.data));
      setToken(res.data.token);
      setUser(res.data);
      toast.success("Sign Up Success!");
      navigate("/search");
    }
  };

  const login = async (email: string, password: string) => {
    const res = await loginAPI(email, password);
    if (res && res.data) {
      localStorage.setItem("token", res.data.token);
      localStorage.setItem("user", JSON.stringify(res.data));
      setToken(res.data.token);
      setUser(res.data);
      toast.success("Login Success!");
      navigate("/search");
    }
  };

  const isLoggedIn = () => {
    return !!user;
  };

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken(null);
    navigate("/");
  };

  return (
    <UserContext.Provider
      value={{ login, user, token, logout, isLoggedIn, signUp }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);