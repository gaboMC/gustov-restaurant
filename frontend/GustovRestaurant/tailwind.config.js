/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
    "./node_modules/flowbite/**/*.js"

  ],
  theme: {
    extend: {
      colors: {
        primary: {
          "50":"#eff6ff",
          "100":"#dbeafe",
          "200":"#bfdbfe",
          "300":"#93c5fd",
          "400":"#60a5fa",
          "500":"#3b82f6",
          "600":"#2563eb",
          "700":"#1d4ed8",
          "800":"#1e40af",
          "900":"#1e3a8a",
          "950":"#172554"
        },
        custom: {
          'primary-gustov': {
            '50': '#eef7ff',
            '100': '#dceeff',
            '200': '#b2dfff',
            '300': '#6dc6ff',
            '400': '#20a8ff',
            '500': '#008dff',
            '600': '#006edf',
            '700': '#0057b4',
            '800': '#004a94',
            '900': '#003366',
          },
          'secondary-gustov': {
            '50': '#f9f9f9',
            '100': '#f2f2f2',
            '200': '#e0e0e0',
            '300': '#c7c7c7',
            '400': '#a8a8a8',
            '500': '#8c8c8c',
            '600': '#6f6f6f',
            '700': '#545454',
            '800': '#3d3d3d',
            '900': '#292929',
            '950': '#141414',
},

        }
      }
    },
  },
  fontFamily: {
    'body': [
      'Inter',
      'ui-sans-serif',
      'system-ui',
      '-apple-system',
      'system-ui',
      'Segoe UI',
      'Roboto',
      'Helvetica Neue',
      'Arial',
      'Noto Sans',
      'sans-serif',
      'Apple Color Emoji',
      'Segoe UI Emoji',
      'Segoe UI Symbol',
      'Noto Color Emoji'
    ],
    'sans': [
      'Inter',
      'ui-sans-serif',
      'system-ui',
      '-apple-system',
      'system-ui',
      'Segoe UI',
      'Roboto',
      'Helvetica Neue',
      'Arial',
      'Noto Sans',
      'sans-serif',
      'Apple Color Emoji',
      'Segoe UI Emoji',
      'Segoe UI Symbol',
      'Noto Color Emoji'
    ]
  },
  plugins: [
    require('flowbite/plugin')
  ],
}

