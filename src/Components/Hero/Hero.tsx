import React from 'react';
import './Hero.css';
import hero from './hero.png';

interface Props {}

const Hero = (props: Props) => {
  return (
    <div className="hero-section">
      <div className="hero-content">
        <h1>Welcome to Parcel</h1>
        <h2>Your Path to E-commerce Success</h2>
        <p>
          Transform your ideas into a thriving online store with Parcel—an
          all-in-one solution for creating, launching, and managing your
          e-commerce website
        </p>
        <button className="join-btn">Join us now</button>
      </div>
      <div className="hero-preview">
        <img src={hero} alt="Hero" />
      </div>
    </div>
  );
};

export default Hero;
