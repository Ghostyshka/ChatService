import { Button } from "react-bootstrap";
import MessageContainer from "./MessageContainer";
import SendMessageForm from "./SendMessageForm";

const Chat =({messages, sendMessage, closeConnection}) => <div>
    <div className="leave-room">
        <Button variant="danger" onClick={() => closeConnection()}>Leave from Chat</Button>
    </div>
    <div className="chat">
        <MessageContainer messages = {messages} />
        <SendMessageForm sendMessage={sendMessage} />
    </div>
</div>

export default Chat;