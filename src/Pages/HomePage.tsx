import React from "react";
import Hero from "../Components/Hero/Hero";
import Navbar from "../Components/Navbar/Navbar"; // Import the Navbar component

type Props = {};

const HomePage = (props: Props) => {
  return (
    <>
      <Navbar />
      <Hero />
    </>
  );
};

export default HomePage;

export {};