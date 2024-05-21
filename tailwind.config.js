/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./index.htmnl", "./src/**/*.{js,jsx,ts,tsx}"],
  darkMode: "class",
  theme: {
    screens: {
      sm: "480px",
      md: "768px",
      lg: "1020px",
      xl: "1440px",
    },
    extend: {
      colors: {
        // primary: "#fea928",
        // secondary: "#ed8900",
        primary: "hsl(213.86, 58.82%, 46.67%)",
        secondary: "hsl(156.62, 73.33%, 58.82%)",
        lightBlue: "hsl(215.02, 98.39%, 51.18%)",
        darkBlue: "hsl(213.86, 58.82%, 46.67%)",
        lightGreen: "hsl(156.62, 73.33%, 58.82%)",
      },
      fontFamily: {
        sans: ["Poppins", "sans-serif"],
      },
      spacing: {
        180: "32rem",
      },
      container:{
        center:true,
        padding: {
          DEFAULT: '1rem',
          sm: '3rem',
        }
      },
    },
  },
  plugins: [],
};