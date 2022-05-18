import styles from '../styles/Home.module.css'
import Head from 'next/head'
import { useRouter } from 'next/router'
var array = []



export default function Messages() {
    const router = useRouter()
    const id = router.query.id

    

    const threadurl = "http://localhost:3000/thread?id="

    const createThread = "http://localhost:3000/createThread?id=" + id

    


    const handleClick = (e, path) => {
        if (path === "refresh") {
          console.log("Refresh");
          refresh(true);
        }
    }
    const refresh = async (event, run) => {
      const endpoint = "https://localhost:7287/MessageBoard/GetAllThreads"

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
          for (const [key, value] of Object.entries(res.data))
          {
            
            if (id != undefined && array.includes(key) === false)
            {
              var threadHolder = document.createElement("a")
              threadHolder.setAttribute("className", styles.thread)
              var threadURL = threadurl + id +"&name=" + value.name +"&thread="+ key
              console.log("++" + threadURL)
              threadHolder.setAttribute("href", threadURL)
              var nameHolder = document.createElement("h4")
              nameHolder.innerHTML = value.name
              threadHolder.appendChild(nameHolder)
              box.appendChild(threadHolder)
              array.push(key)
            }
          }
        }
    }))
      
    }

    refresh()

    return (
      <div>
        <Head>
        <title>Messages Home</title>
        </Head>
        <h1 className={styles.title}>Threads</h1>
        <a onClick={(e) => handleClick(e, "refresh")} className={styles.box}>Refresh Threads</a><br></br>
        <a href={createThread} className={styles.box}>Create Thread</a><br></br>
        <div id='threads' className={styles.threadbox}></div>
        
        
      </div>
    )
  }