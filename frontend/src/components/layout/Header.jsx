import { useNavigate } from 'react-router-dom'

export default function Header({ user, onLogout }) {
  const navigate = useNavigate()

  const initials = user?.fullName
    ? user.fullName.split(' ').map((n) => n[0]).join('').toUpperCase().slice(0, 2)
    : 'JD'

  return (
    <header className="bg-blue-950 text-white px-6 py-3 flex justify-between items-center shadow-lg z-10">
      <div className="flex items-center gap-3">
        <div className="bg-white text-blue-950 font-bold rounded-lg px-3 py-1.5 text-sm">Y</div>
        <h1 className="text-xl font-bold tracking-wide">YMS Pro</h1>
      </div>

      <div className="flex items-center gap-4">
        {user?.role === 'Admin' && (
          <button
            onClick={() => navigate('/admin')}
            className="bg-blue-800 hover:bg-blue-700 px-4 py-1.5 rounded-xl text-sm font-medium transition-colors"
          >
            Admin Panel
          </button>
        )}
        <div className="flex items-center gap-2">
          <span className="text-sm text-blue-200">{user?.fullName}</span>
          <button
            onClick={onLogout}
            className="w-9 h-9 rounded-full bg-white text-blue-950 flex items-center justify-center font-bold text-sm hover:bg-blue-100 transition-colors"
            title="Logout"
          >
            {initials}
          </button>
        </div>
      </div>
    </header>
  )
}
