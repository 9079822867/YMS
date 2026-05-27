export default function Spinner({ size = 'md' }) {
  const sz = size === 'sm' ? 'h-5 w-5' : size === 'lg' ? 'h-10 w-10' : 'h-7 w-7'
  return (
    <div className={`${sz} animate-spin rounded-full border-4 border-blue-200 border-t-blue-600`} />
  )
}
