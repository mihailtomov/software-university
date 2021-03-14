import style from './App.module.css';

import Navigation from './components/Navigation/Navigation.js';
import Aside from './components/Aside/Aside.js';
import Main from './components/Main/Main.js';
import Footer from './components/Footer/Footer.js';

function App() {
  return (
    <div className={style.App}>
      <Navigation />

      <div className={style.Container}>
        <Aside />
        <Main />
      </div>
      
      <Footer />
    </div>
  );
}

export default App;
