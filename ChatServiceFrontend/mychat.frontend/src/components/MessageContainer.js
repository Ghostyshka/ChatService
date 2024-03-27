
const MessageContainer = ({message}) => {

    return <div className="message-container">
        {message.map((m, index) =>
        <div key={index} className="user-message">
            <div className="message bg-primary">{m.message}</div>
            <div className="from-user">{m.user}</div>
        </div> 
        )}
    </div>
}

export default MessageContainer;