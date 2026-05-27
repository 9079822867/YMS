import { useEffect, useState, useCallback } from 'react'
import { useNavigate } from 'react-router-dom'
import { inventoryApi, mastersApi } from '../services/api'
import MainLayout from '../components/layout/MainLayout'
import { RunningBadge, KeyBadge, RcBadge } from '../components/common/StatusBadge'
import Spinner from '../components/common/Spinner'

const PAGE_SIZES = [10, 25, 50, 100]

const defaultFilters = {
  clientName: '', state: '', yardName: '', yardCity: '',
  vehicleType: '', loanNumber: '', registrationNumber: '',
  chassisNumber: '', engineNumber: '',
  runningStatus: '', keyStatus: '', rcStatus: '',
  entryFrom: '', entryTo: '',
}

export default function Inventory() {
  const navigate = useNavigate()
  const [filters, setFilters] = useState(defaultFilters)
  const [applied, setApplied] = useState(defaultFilters)
  const [data, setData] = useState({ items: [], totalCount: 0, totalPages: 1 })
  const [page, setPage] = useState(1)
  const [pageSize, setPageSize] = useState(25)
  const [loading, setLoading] = useState(false)
  const [states, setStates] = useState([])
  const [vehicleTypes, setVehicleTypes] = useState([])
  const [runningStatuses, setRunningStatuses] = useState([])

  useEffect(() => {
    mastersApi.getStates().then(({ data }) => setStates(data)).catch(() => {})
    mastersApi.getVehicleTypes().then(({ data }) => setVehicleTypes(data)).catch(() => {})
    mastersApi.getRunningStatuses().then(({ data }) => setRunningStatuses(data)).catch(() => {})
  }, [])

  const fetchData = useCallback(async () => {
    setLoading(true)
    try {
      const params = { ...applied, page, pageSize }
      Object.keys(params).forEach((k) => { if (!params[k]) delete params[k] })
      const { data: result } = await inventoryApi.search(params)
      setData(result)
    } catch {
      setData({ items: [], totalCount: 0, totalPages: 1 })
    } finally {
      setLoading(false)
    }
  }, [applied, page, pageSize])

  useEffect(() => { fetchData() }, [fetchData])

  const handleSearch = () => { setPage(1); setApplied({ ...filters }) }
  const handleClear = () => { setFilters(defaultFilters); setApplied(defaultFilters); setPage(1) }
  const setFilter = (key, val) => setFilters((f) => ({ ...f, [key]: val }))

  return (
    <MainLayout>
      <div className="flex h-[calc(100vh-56px)] overflow-hidden">
        {/* Sidebar Filters */}
        <aside className="w-72 bg-white shadow-lg p-4 overflow-y-auto flex-shrink-0">
          <h2 className="text-lg font-bold mb-4 flex items-center gap-2">
            <span className="text-blue-600">☰</span> Search Filters
          </h2>

          <div className="space-y-3">
            {[
              { label: 'Client Name', key: 'clientName', placeholder: 'Client name' },
              { label: 'Loan Number', key: 'loanNumber', placeholder: 'Loan number' },
              { label: 'Registration No', key: 'registrationNumber', placeholder: 'Reg number' },
              { label: 'Chassis No', key: 'chassisNumber', placeholder: 'Chassis number' },
              { label: 'Engine No', key: 'engineNumber', placeholder: 'Engine number' },
              { label: 'Yard Name', key: 'yardName', placeholder: 'Yard name' },
              { label: 'Yard City', key: 'yardCity', placeholder: 'City' },
            ].map(({ label, key, placeholder }) => (
              <div key={key}>
                <label className="block text-xs font-semibold text-gray-600 mb-1">{label}</label>
                <input
                  className="input-field text-xs"
                  placeholder={placeholder}
                  value={filters[key]}
                  onChange={(e) => setFilter(key, e.target.value)}
                />
              </div>
            ))}

            <div>
              <label className="block text-xs font-semibold text-gray-600 mb-1">State</label>
              <select className="input-field text-xs" value={filters.state} onChange={(e) => setFilter('state', e.target.value)}>
                <option value="">All States</option>
                {states.map((s) => <option key={s} value={s}>{s}</option>)}
              </select>
            </div>

            <div>
              <label className="block text-xs font-semibold text-gray-600 mb-1">Vehicle Type</label>
              <select className="input-field text-xs" value={filters.vehicleType} onChange={(e) => setFilter('vehicleType', e.target.value)}>
                <option value="">All Types</option>
                {vehicleTypes.map((t) => <option key={t} value={t}>{t}</option>)}
              </select>
            </div>

            <div>
              <label className="block text-xs font-semibold text-gray-600 mb-1">Running Status</label>
              <select className="input-field text-xs" value={filters.runningStatus} onChange={(e) => setFilter('runningStatus', e.target.value)}>
                <option value="">All Statuses</option>
                {runningStatuses.map((s) => <option key={s} value={s}>{s}</option>)}
              </select>
            </div>

            <div>
              <label className="block text-xs font-semibold text-gray-600 mb-1">RC Status</label>
              <select className="input-field text-xs" value={filters.rcStatus} onChange={(e) => setFilter('rcStatus', e.target.value)}>
                <option value="">All</option>
                {['Submitted', 'Pending', 'Not Available', 'Duplicate'].map((s) => (
                  <option key={s} value={s}>{s}</option>
                ))}
              </select>
            </div>

            <div>
              <label className="block text-xs font-semibold text-gray-600 mb-1">Entry Date (From)</label>
              <input type="date" className="input-field text-xs" value={filters.entryFrom} onChange={(e) => setFilter('entryFrom', e.target.value)} />
            </div>
            <div>
              <label className="block text-xs font-semibold text-gray-600 mb-1">Entry Date (To)</label>
              <input type="date" className="input-field text-xs" value={filters.entryTo} onChange={(e) => setFilter('entryTo', e.target.value)} />
            </div>

            <button onClick={handleSearch} className="w-full btn-primary py-2 text-sm mt-1">
              Search
            </button>
            <button onClick={handleClear} className="w-full btn-secondary py-2 text-sm">
              Clear Filters
            </button>
          </div>
        </aside>

        {/* Main Content */}
        <div className="flex-1 p-4 overflow-y-auto">
          <div className="bg-white rounded-2xl shadow-md overflow-hidden">
            {/* Toolbar */}
            <div className="flex items-center justify-between px-5 py-3 border-b">
              <div className="flex items-center gap-2">
                <span className="font-semibold text-gray-700">
                  Search Results
                </span>
                {!loading && (
                  <span className="text-sm text-gray-500">({data.totalCount.toLocaleString()} found)</span>
                )}
              </div>
              <div className="flex items-center gap-2">
                <button onClick={() => navigate('/inventory/new')} className="btn-primary text-sm py-1.5">
                  + New Entry
                </button>
                <button className="btn-success text-sm py-1.5">
                  Export Excel
                </button>
              </div>
            </div>

            {loading ? (
              <div className="flex justify-center py-20"><Spinner size="lg" /></div>
            ) : (
              <>
                <div className="overflow-x-auto">
                  <table className="w-full text-sm min-w-[1100px]">
                    <thead className="bg-blue-600 text-white text-xs">
                      <tr>
                        {['#', 'Yard ID', 'Client Name', 'Loan No', 'Yard Name', 'City', 'State',
                          'Vehicle Type', 'Reg No', 'Chassis No', 'Entry Date',
                          'Running Status', 'Key', 'RC Status', 'Charges', 'Action'].map((h) => (
                          <th key={h} className="px-3 py-3 text-left font-semibold whitespace-nowrap">{h}</th>
                        ))}
                      </tr>
                    </thead>
                    <tbody>
                      {data.items.length === 0 ? (
                        <tr>
                          <td colSpan={16} className="text-center py-16 text-gray-400">No records found</td>
                        </tr>
                      ) : data.items.map((item, idx) => (
                        <tr key={item.id} className="border-b hover:bg-blue-50 transition-colors">
                          <td className="px-3 py-2 text-gray-500">{(page - 1) * pageSize + idx + 1}</td>
                          <td className="px-3 py-2 font-mono text-gray-700">{item.id}</td>
                          <td className="px-3 py-2">{item.clientName}</td>
                          <td className="px-3 py-2 font-mono text-xs">{item.loanNumber}</td>
                          <td className="px-3 py-2">{item.yardName}</td>
                          <td className="px-3 py-2">{item.yardCity}</td>
                          <td className="px-3 py-2">{item.yardState}</td>
                          <td className="px-3 py-2">{item.vehicleType}</td>
                          <td className="px-3 py-2 font-mono text-xs">{item.registrationNumber}</td>
                          <td className="px-3 py-2 font-mono text-xs">{item.chassisNumber}</td>
                          <td className="px-3 py-2 text-xs">{new Date(item.entryDate).toLocaleDateString('en-IN')}</td>
                          <td className="px-3 py-2"><RunningBadge status={item.runningStatus} /></td>
                          <td className="px-3 py-2"><KeyBadge status={item.keyStatus} /></td>
                          <td className="px-3 py-2"><RcBadge status={item.rcStatus} /></td>
                          <td className="px-3 py-2 font-semibold text-gray-700">₹{item.parkingCharges?.toFixed(0)}</td>
                          <td className="px-3 py-2">
                            <button
                              onClick={() => navigate(`/inventory/${item.id}`)}
                              className="bg-red-600 hover:bg-red-700 text-white text-xs px-3 py-1 rounded-lg transition-colors"
                            >
                              View/Edit
                            </button>
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>

                {/* Pagination */}
                <div className="flex items-center justify-between px-5 py-3 border-t text-sm text-gray-600">
                  <div className="flex items-center gap-2">
                    <span>Show</span>
                    <select
                      className="border rounded px-2 py-1 text-sm"
                      value={pageSize}
                      onChange={(e) => { setPageSize(Number(e.target.value)); setPage(1) }}
                    >
                      {PAGE_SIZES.map((s) => <option key={s} value={s}>{s}</option>)}
                    </select>
                    <span>entries</span>
                  </div>
                  <div className="flex items-center gap-1">
                    <button
                      className="px-3 py-1 rounded border hover:bg-gray-100 disabled:opacity-40"
                      onClick={() => setPage((p) => Math.max(1, p - 1))}
                      disabled={page === 1}
                    >Previous</button>
                    {Array.from({ length: Math.min(5, data.totalPages) }, (_, i) => {
                      const p = Math.max(1, Math.min(page - 2, data.totalPages - 4)) + i
                      return (
                        <button
                          key={p}
                          onClick={() => setPage(p)}
                          className={`px-3 py-1 rounded border ${page === p ? 'bg-blue-600 text-white border-blue-600' : 'hover:bg-gray-100'}`}
                        >{p}</button>
                      )
                    })}
                    <button
                      className="px-3 py-1 rounded border hover:bg-gray-100 disabled:opacity-40"
                      onClick={() => setPage((p) => Math.min(data.totalPages, p + 1))}
                      disabled={page === data.totalPages}
                    >Next</button>
                  </div>
                  <span>Page {page} of {data.totalPages}</span>
                </div>
              </>
            )}
          </div>
        </div>
      </div>
    </MainLayout>
  )
}
