/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
    "./node_modules/flowbite/**/*.js"

  ],
  darkMode: 'class',
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
            '50': '#fff8e6',
            '100': '#ffedcc',
            '200': '#ffd699',
            '300': '#ffbf66',
            '400': '#ffa733',
            '500': '#ff8f00',
            '600': '#e68100',
            '700': '#b36600',
            '800': '#804c00',
            '900': '#4d2d00',
            '950': '#331d00',
        }

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

