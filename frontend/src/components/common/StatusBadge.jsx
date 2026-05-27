const runningColors = {
  Running: 'bg-green-600',
  'Red/Idle': 'bg-red-600',
  Auctioned: 'bg-purple-600',
  Released: 'bg-blue-500',
  Sold: 'bg-teal-600',
  Scrap: 'bg-gray-500',
}

const keyColors = {
  Yes: 'bg-yellow-500',
  No: 'bg-orange-500',
  'Duplicate Key': 'bg-amber-600',
  Missing: 'bg-red-500',
}

const rcColors = {
  Submitted: 'bg-blue-600',
  Pending: 'bg-gray-400',
  'Not Available': 'bg-red-400',
  Duplicate: 'bg-orange-600',
}

export function RunningBadge({ status }) {
  return (
    <span className={`inline-block px-2.5 py-0.5 rounded-full text-white text-xs font-semibold ${runningColors[status] ?? 'bg-gray-400'}`}>
      {status}
    </span>
  )
}

export function KeyBadge({ status }) {
  return (
    <span className={`inline-block px-2.5 py-0.5 rounded-full text-white text-xs font-semibold ${keyColors[status] ?? 'bg-gray-400'}`}>
      {status}
    </span>
  )
}

export function RcBadge({ status }) {
  return (
    <span className={`inline-block px-2.5 py-0.5 rounded-full text-white text-xs font-semibold ${rcColors[status] ?? 'bg-gray-400'}`}>
      {status}
    </span>
  )
}
