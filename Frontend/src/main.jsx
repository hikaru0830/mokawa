import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
// import './index.css'
import App from './App.jsx'
import {createHashRouter, RouterProvider} from 'react-router'
import routes from './routes/route.jsx'

const router = createHashRouter(routes)

createRoot(document.getElementById('root')).render(
  <RouterProvider router={router} />
  // <StrictMode>
  //   <App />
  // </StrictMode>,
)
