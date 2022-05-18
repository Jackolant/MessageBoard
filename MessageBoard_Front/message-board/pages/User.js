import Head from 'next/head'
import styles from '../styles/Home.module.css'
    
export default function SignUp() 
{
    const handleSubmit = async (event) => {
        // Stop the form from submitting and refreshing the page.
        event.preventDefault()
    
        // Get data from the form.
        var data = {
            firstName: event.target.first.value,
            lastName: event.target.last.value,
            email: event.target.email.value,
            password: event.target.pass.value,
        }

        const endpoint = "https://localhost:7287/MessageBoard/SignUp"
        
        var FormData = new URLSearchParams(Object.entries(data)).toString()

        var myHeaders = new Headers();
myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: FormData,
            mode: 'cors'
        };

        var response = fetch(endpoint, requestOptions)

        var result = (await response).text()
        var array = (await result).split(':')
        var second = array[1]
        var id = second.trim()
        window.location.href = 'http://localhost:3000/UserSuccess?id=' + id;

}
    return (
    <div className={styles.container}>
        <Head>
            <title>User Sign Up</title>
        </Head>

        
        <main className={styles.main}>

            <h1 className={styles.title}>User Sign Up</h1>

            <form onSubmit={handleSubmit}>
                <label htmlFor="first">First Name</label><br></br>
                <input type="text" id="first" size="50" maxLength="40"></input><br></br>
                <label htmlFor="last">Last Name</label><br></br>
                <input type="text" id="last" size="50" maxLength="40"></input><br></br>
                <label htmlFor="email">Email</label><br></br>
                <input type="email" id="email" size="50" maxLength="40"></input><br></br>
                <label htmlFor="pass">Password</label><br></br>
                <input type="text" id="pass" size="50" maxLength="40"></input><br></br><br></br>
                <button type="submit">Submit</button>
            </form>


        </main>
    </div>
    )
  }