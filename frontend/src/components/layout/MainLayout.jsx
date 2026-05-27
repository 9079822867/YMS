import { useNavigate } from 'react-router-dom'
import Header from './Header'
import { useAuth } from '../../hooks/useAuth'

export default function MainLayout({ children }) {
  const { user, logout } = useAuth()
  const navigate = useNavigate()

  const handleLogout = () => {
    logout()
    navigate('/')
  }

  return (
    <div className="min-h-screen flex flex-col">
      <Header user={user} onLogout={handleLogout} />
      <main className="flex-1">{children}</main>
    </div>
  )
}
