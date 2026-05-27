import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { dashboardApi } from '../services/api'
import MainLayout from '../components/layout/MainLayout'
import StatsCard from '../components/common/StatsCard'
import Spinner from '../components/common/Spinner'

export default function Dashboard() {
  const navigate = useNavigate()
  const [stats, setStats] = useState(null)
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    dashboardApi.getStats()
      .then(({ data }) => setStats(data))
      .catch(() => {})
      .finally(() => setLoading(false))
  }, [])

  return (
    <MainLayout>
      <div className="p-6">
        <div className="flex items-center justify-between mb-6">
          <h2 className="text-2xl font-bold text-gray-800">Dashboard</h2>
          <button onClick={() => navigate('/inventory')} className="btn-primary">
            View Inventory
          </button>
        </div>

        {loading ? (
          <div className="flex justify-center py-20"><Spinner size="lg" /></div>
        ) : (
          <>
            <div className="grid grid-cols-2 md:grid-cols-4 gap-4 mb-6">
              <StatsCard label="Total Vehicles" value={stats?.totalVehicles} />
              <StatsCard label="Running" value={stats?.runningVehicles} color="text-green-600" />
              <StatsCard label="Red / Idle" value={stats?.idleVehicles} color="text-red-600" />
              <StatsCard label="Pending RC" value={stats?.pendingRc} color="text-yellow-600" />
            </div>
            <div className="grid grid-cols-2 md:grid-cols-3 gap-4">
              <StatsCard label="Submitted Reports" value={stats?.submittedReports} color="text-blue-600" />
              <StatsCard label="Active Yards" value={stats?.activeYards} />
              <StatsCard
                label="Total Parking Charges (₹)"
                value={stats?.totalParkingCharges?.toLocaleString('en-IN', { maximumFractionDigits: 0 })}
              />
            </div>
          </>
        )}
      </div>
    </MainLayout>
  )
}
