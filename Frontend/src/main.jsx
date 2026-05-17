import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
// import './index.css'
import App from './App.jsx'
import {createHashRouter, RouterProvider} from 'react-router'
import routes from './routes/route.jsx'
import { store } from './store.js'
import { Provider } from 'react-redux'

const router = createHashRouter(routes)

createRoot(document.getElementById('root')).render(
  <Provider store={store}>
    <RouterProvider router={router} />
  </Provider>
  // <StrictMode>
  //   <App />
  // </StrictMode>,
)
