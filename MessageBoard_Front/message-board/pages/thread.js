import styles from '../styles/Home.module.css'
import Head from 'next/head'
import { useRouter } from 'next/router'
var array = []

export default function Thread() {
    const router = useRouter()
    const id = router.query.id
    const name = router.query.name
    const threadID = router.query.thread

    const currentPage = "http://localhost:3000/thread?id=" + id + "&name=" + name + "&thread=" + threadID
    const MessageHome = "http://localhost:3000/messagesHome?id="+id

    const handleSubmit = async (event) => {


        var data = {
            message: event.target.message.value,
            thread: threadID,
            owner: id,
        }

        const messageEndpoint = "https://localhost:7287/MessageBoard/AddMessage"

        var FormData = new URLSearchParams(Object.entries(data)).toString()

        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: FormData,
            mode: 'cors'
        };

        fetch(messageEndpoint, requestOptions).then(resp => resp.json().then(data => ({
            data: data,
            status: resp.status
        })).then(res => {
            if (res.status == 200)
            {
                console.log("Success")
                window.location.href = currentPage
            }
            else
            {
                console.log("Error Creating Thread")
            }
        }))
    }
    
    const getThread = async (event) => {
        //if (refreshed === false)

            const endpoint = "https://localhost:7287/MessageBoard/GetThread/"+threadID

            var requestOptions = {
                method: 'GET',
                mode: 'cors'
            }
            const box = document.getElementById("threads")

            fetch(endpoint, requestOptions).then(resp => resp.json().then(data => ({
                    data: data,
                    status: resp.status
                })).then(res => {
                    if (res.status == 200)
                    {                        
                        for (const [key, value] of Object.entries(res.data.messages))
                        {
                            if (array.includes(key) === false)
                            {
                            var messageBox = document.createElement("div")
                            messageBox.setAttribute("className", styles.messageBox)
                            messageBox.setAttribute("id", "key")
                            var owner = document.createElement("h4")
                            var message = document.createElement("p")
                            owner.innerHTML = "User: " + value.owner + ":"
                            message.innerHTML = value.message
                            messageBox.appendChild(owner)
                            messageBox.appendChild(message)
                            box.appendChild(messageBox)
                            array.push(key)
                            }
                        }
                    }
                }))
  //  }

    }
    getThread()

    const handleClick = (e, path) => {
        if (path === "refresh") {
            console.log("Refreshing....")
            getThread()
        }
    }

    return (
      <div>
        <Head>
        <title>Thread</title>
        </Head>
        <h1 className={styles.title}>{name}</h1>
        <a href={MessageHome} className={styles.sideBtn}>View All Threads</a>
        <a onClick={(e) => handleClick(e, "refresh")} className={styles.sideBtn}>Refresh</a>
        <div id='threads' className={styles.threadbox}>

        </div>

        <div className={styles.threadbox}>
            <form onSubmit={handleSubmit}>
                <label htmlFor="message">Message</label><br></br>
                <input type="text" id="message" size="50" maxLength="40"></input><br></br>
                <button type="submit">Reply</button>
            </form>
            
        </div>
        
        
      </div>
    )
  }