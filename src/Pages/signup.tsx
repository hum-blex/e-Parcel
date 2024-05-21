import { useState } from "react";

import React from 'react';

const Signup = () => {
  const [formData, setFormData] = React.useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: '',
    submitted: false,
    isEmailValid: false
  });

  const validateEmail = (email: string): boolean => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  };
  const submitForm = () => {
    setFormData({ ...formData, submitted: true, isEmailValid: validateEmail(formData.email) });
    if (formData.name && formData.email && formData.isEmailValid && formData.password && formData.confirmPassword && formData.password === formData.confirmPassword) {
      console.log('Form submitted successfully!');
    }
  };

  return (
    <div className="bg-gray-300">
    <div className="flex items-center justify-center min-h-screen">
      <div className="bg-gray-100 p-8 rounded-lg shadow-md w-full max-w-md">
        <h2 className="text-2xl font-bold mb-6 text-center">Sign Up</h2>
        <form onSubmit={(e) => { e.preventDefault(); submitForm(); }}>
          <div className="mb-4">
            <label className="block text-gray-700 font-bold mb-2" htmlFor="name">
              Full Name
            </label>
            <input
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="name"
              type="text"
              placeholder="Enter your full name"
              value={formData.name}
              onChange={(e) => setFormData({ ...formData, name: e.target.value })}
              required
            />
            {formData.submitted && !formData.name && <span className="text-red-500 text-sm">Full name is required</span>}
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 font-bold mb-2" htmlFor="email">
              Email
            </label>
            <input
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="email"
              type="email"
              placeholder="Enter your email"
              value={formData.email}
              onChange={(e) => setFormData({ ...formData, email: e.target.value })}
              required
            />
            {formData.submitted && !formData.email && <span className="text-red-500 text-sm">Email is required</span>}
            {formData.submitted && formData.email && !formData.isEmailValid && <span className="text-red-500 text-sm">Email is not valid</span>}
          </div>
          <div className="mb-6">
            <label className="block text-gray-700 font-bold mb-2" htmlFor="password">
              Password
            </label>
            <input
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
              id="password"
              type="password"
              placeholder="Enter your password"
              value={formData.password}
              onChange={(e) => setFormData({ ...formData, password: e.target.value })}
              required
            />
            {formData.submitted && !formData.password && <span className="text-red-500 text-sm">Password is required</span>}
          </div>
          <div className="mb-6">
            <label className="block text-gray-700 font-bold mb-2" htmlFor="confirmPassword">
              Confirm Password
            </label>
            <input
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
              id="confirmPassword"
              type="password"
              placeholder="Confirm your password"
              value={formData.confirmPassword}
              onChange={(e) => setFormData({ ...formData, confirmPassword: e.target.value })}
              required
            />
            {formData.submitted && !formData.confirmPassword && <span className="text-red-500 text-sm">Confirm password is required</span>}
            {formData.submitted && formData.confirmPassword && formData.password !== formData.confirmPassword && <span className="text-red-500 text-sm">Passwords do not match</span>}
          </div>
          <div className="flex items-center justify-between">
            <button
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
              type="submit"
            >
            <a href="/login">Sign Up</a>  
            </button>
          </div>
        </form>
      </div>
    </div>
    </div>
  );
};

export default Signup;
