import Head from 'next/head'
import styles from '../styles/Home.module.css'
import { useRouter } from 'next/router'
    
export default function CreateThread() 
{
    const router = useRouter()
    const id = router.query.id

    const threadPage = "http://localhost:3000/thread?id=" + id + "&name="

    const handleSubmit = async (event) => {
        // Stop the form from submitting and refreshing the page.
        event.preventDefault()

        var name = event.target.name.value

        const endpoint = "https://localhost:7287/MessageBoard/CreateThread/"+id+"/"+name

        var requestOptions = {
            method: 'POST',
            //mode: 'cors'
        };

        fetch(endpoint, requestOptions).then(resp => resp.json().then(data => ({
            data: data,
            status: resp.status
        })).then(res => {
            if (res.status == 200)
            {
                console.log("Success")
                window.location.href = threadPage+name+"&thread="+res.data.id 
            }
            else
            {
                console.log("Error Creating Thread")
            }
        }))


}
    return (
    <div className={styles.container}>
        <Head>
            <title>User Sign Up</title>
        </Head>

        
        <main className={styles.main}>

            <h1 className={styles.title}>Create Thread</h1>

            <form onSubmit={handleSubmit}>
                <label htmlFor="name">Name</label><br></br>
                <input type="text" id="name" size="50" maxLength="40"></input><br></br>
                <button type="submit">Submit</button>
            </form>


        </main>
    </div>
    )
  }