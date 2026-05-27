export default function StatsCard({ label, value, color = 'text-gray-800', icon }) {
  return (
    <div className="card">
      <p className="text-gray-500 text-sm">{label}</p>
      <h2 className={`text-3xl font-bold mt-1 ${color}`}>{value?.toLocaleString() ?? '—'}</h2>
    </div>
  )
}
