import styles from '../styles/Home.module.css'
import Head from 'next/head'
import { useRouter } from 'next/router'

export default function Success() {

    const router = useRouter()
    const id = router.query.id
    const nextPage = "http://localhost:3000/messagesHome?id=" + id

    return (
        <div className={styles.container}>
            <Head>
            <title>Success!</title>
            </Head>

        <h1 className={styles.title}>Success! User Created!</h1>
        <p className={styles.description}>User ID: {id}</p>
          <a href={nextPage} className={styles.box}> Head over to the Message Board</a>
        </div>
)
  }