import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'

export default function Home() {
  return (
    <div className={styles.container}>
      <Head>
        <title>Message Board</title>
      </Head>

      <main className={styles.main}>
        <h1 className={styles.title}>
          Welcome to My Message Board!
        </h1>

        <a className={styles.box} href="http://localhost:3000/User">
          Sign Up New User
        </a>

      </main>

      <footer className={styles.footer}>
      </footer>
    </div>
  )
}
