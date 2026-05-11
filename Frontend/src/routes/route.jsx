import Layout from '../Layout';
import Home from '../pages/home/Home';
import About from '../pages/about/About';

const routes = [
  {
    path: '/',
    element: <Layout />,
    children: [
      {
        path: 'home',
        element: <Home />
      },
      {
        path: 'about',
        element: <About />
      }
    ]
  }
]

export default routes;