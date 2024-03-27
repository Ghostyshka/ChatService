import './App.css';
import 'bootstrap/dist/css/bootsrtap.min.css';
import Lobby from './components/Lobby';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

const App = () => {

  const joinRoom = async (user, room) =>{
    try{
      const connection = new HubConnectionBuilder()
      .withUrl("https://localhost:7049/chat")
      .configureLogging(LogLevel.Information)
      .build();

      connection.on("ReceiveMessage", (user, message) => {
        console.log('messege received:', message);
      });

      await connection.start();
      await connection.invoke("JoinRoom", {user, room});

    } catch(e){
      console.log(e);
    }
  }

  return <div className='app'>
    <h2>MyChat</h2>
    <hr className='line'/>
    <Lobby joinRoom={joinRoom}/>
  </div>
}

export default App;
