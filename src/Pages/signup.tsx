import React, { useState } from 'react';

const Signup = () => {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    confirmPassword: '',
    submitted: false,
    isEmailValid: false,
    isPasswordValid: false,
    isFirstNameValid: false,
    isLastNameValid: false
  });

  const validateEmail = (email: string): boolean => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  };

  const validateForm = () => {
    const isEmailValid = validateEmail(formData.email);
    const isPasswordValid = formData.password.length >= 8;
    const isFirstNameValid = formData.firstName.trim().length > 0;
    const isLastNameValid = formData.lastName.trim().length > 0;
    setFormData({
      ...formData,
      submitted: true,
      isEmailValid,
      isPasswordValid,
      isFirstNameValid,
      isLastNameValid
    });
    return isEmailValid && isPasswordValid && isFirstNameValid && isLastNameValid && formData.password === formData.confirmPassword;
  };

  const submitForm = () => {
    if (validateForm()) {
      console.log('Form submitted successfully!');
    }
  };

  return (
    <div className="bg-gray-300">
      <div className="flex items-center justify-center min-h-screen">
        <div className="bg-gray-100 p-8 rounded-lg shadow-md w-full max-w-md">
          <h2 className="text-2xl font-bold mb-6 text-center">Sign Up</h2>
          <form onSubmit={(e) => { e.preventDefault(); submitForm(); }}>
            {/* First Name input */}
            <div className="mb-4">
              <label className="block text-gray-700 font-bold mb-2" htmlFor="firstName">First Name</label>
              <input
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                id="firstName"
                type="text"
                placeholder="Enter your first name"
                value={formData.firstName}
                onChange={(e) => setFormData({ ...formData, firstName: e.target.value })}
                required
              />
              {formData.submitted && !formData.isFirstNameValid && <span className="text-red-500 text-sm">First name is required</span>}
            </div>
            {/* Last Name input */}
            <div className="mb-4">
              <label className="block text-gray-700 font-bold mb-2" htmlFor="lastName">Last Name</label>
              <input
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                id="lastName"
                type="text"
                placeholder="Enter your last name"
                value={formData.lastName}
                onChange={(e) => setFormData({ ...formData, lastName: e.target.value })}
                required
              />
              {formData.submitted && !formData.isLastNameValid && <span className="text-red-500 text-sm">Last name is required</span>}
            </div>
            {/* Email input */}
            <div className="mb-4">
              <label className="block text-gray-700 font-bold mb-2" htmlFor="email">Email</label>
              <input
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                id="email"
                type="email"
                placeholder="Enter your email"
                value={formData.email}
                onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                required
              />
              {formData.submitted && !formData.isEmailValid && <span className="text-red-500 text-sm">Email is not valid</span>}
            </div>
            {/* Password inputs */}
            <div className="mb-6">
              <label className="block text-gray-700 font-bold mb-2" htmlFor="password">Password</label>
              <input
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
                id="password"
                type="password"
                placeholder="Enter your password"
                value={formData.password}
                onChange={(e) => setFormData({ ...formData, password: e.target.value })}
                required
              />
              {formData.submitted && !formData.isPasswordValid && <span className="text-red-500 text-sm">Password must be at least 8 characters</span>}
            </div>
            <div className="mb-6">
              <label className="block text-gray-700 font-bold mb-2" htmlFor="confirmPassword">Confirm Password</label>
              <input
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
                id="confirmPassword"
                type="password"
                placeholder="Confirm your password"
                value={formData.confirmPassword}
                onChange={(e) => setFormData({ ...formData, confirmPassword: e.target.value })}
                required
              />
              {formData.submitted && formData.confirmPassword && formData.password !== formData.confirmPassword && <span className="text-red-500 text-sm">Passwords do not match</span>}
            </div>
            <div className="flex items-center justify-between">
              <button
                className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                type="submit"
              >
                Sign Up
              </button>
              <p className="text-gray-600 text-sm">Already signed up?</p>
              <a href="/login" className="text-blue-500 hover:text-blue-700 text-sm">
                Sign In
              </a>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};
export default Signup;
