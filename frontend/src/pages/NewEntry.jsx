import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { inventoryApi, mastersApi } from '../services/api'
import MainLayout from '../components/layout/MainLayout'

const Section = ({ title, children }) => (
  <div className="card mb-4">
    <h3 className="font-semibold text-gray-700 mb-4 pb-2 border-b text-sm uppercase tracking-wide">{title}</h3>
    <div className="grid grid-cols-1 md:grid-cols-3 gap-4">{children}</div>
  </div>
)

const Field = ({ label, children }) => (
  <div>
    <label className="block text-xs font-medium text-gray-600 mb-1">{label}</label>
    {children}
  </div>
)

export default function NewEntry() {
  const navigate = useNavigate()
  const [clients, setClients] = useState([])
  const [yards, setYards] = useState([])
  const [vehicleTypes, setVehicleTypes] = useState([])
  const [submitting, setSubmitting] = useState(false)
  const [error, setError] = useState('')

  const [form, setForm] = useState({
    clientId: '', yardId: '', loanNumber: '', customerName: '', branchName: '', repoDate: '',
    registrationNumber: '', chassisNumber: '', engineNumber: '',
    make: '', model: '', variant: '', fuelType: '', transmissionType: '',
    manufacturingYear: '', vehicleType: '', color: '',
    runningStatus: 'Running', keyStatus: 'Yes', rcStatus: 'Pending',
    batteryCondition: '', tyreCondition: '', odometerReading: '', insuranceAvailable: false,
    parkingCharges: '', towingCharges: '', miscCharges: '',
  })

  useEffect(() => {
    mastersApi.getClients().then(({ data }) => setClients(data)).catch(() => {})
    mastersApi.getYards().then(({ data }) => setYards(data)).catch(() => {})
    mastersApi.getVehicleTypes().then(({ data }) => setVehicleTypes(data)).catch(() => {})
  }, [])

  const set = (key, val) => setForm((f) => ({ ...f, [key]: val }))

  const handleSubmit = async (e) => {
    e.preventDefault()
    setError('')
    setSubmitting(true)
    try {
      const payload = {
        ...form,
        clientId: Number(form.clientId),
        yardId: Number(form.yardId),
        manufacturingYear: form.manufacturingYear ? Number(form.manufacturingYear) : null,
        odometerReading: form.odometerReading ? Number(form.odometerReading) : null,
        parkingCharges: Number(form.parkingCharges) || 0,
        towingCharges: Number(form.towingCharges) || 0,
        miscCharges: Number(form.miscCharges) || 0,
        repoDate: form.repoDate || null,
      }
      await inventoryApi.create(payload)
      navigate('/inventory')
    } catch (err) {
      setError(err.response?.data?.message || 'Failed to create entry')
    } finally {
      setSubmitting(false)
    }
  }

  return (
    <MainLayout>
      <div className="p-6 max-w-5xl mx-auto">
        <div className="flex items-center justify-between mb-5">
          <h2 className="text-2xl font-bold">New Inventory Entry</h2>
          <button onClick={() => navigate('/inventory')} className="btn-secondary text-sm">
            ← Back
          </button>
        </div>

        {error && (
          <div className="bg-red-50 border border-red-200 text-red-700 rounded-lg px-4 py-3 mb-4 text-sm">{error}</div>
        )}

        <form onSubmit={handleSubmit}>
          <Section title="Ownership & Loan Details">
            <Field label="Client *">
              <select required className="input-field text-sm" value={form.clientId} onChange={(e) => set('clientId', e.target.value)}>
                <option value="">Select Client</option>
                {clients.map((c) => <option key={c.id} value={c.id}>{c.name}</option>)}
              </select>
            </Field>
            <Field label="Loan Number *">
              <input required className="input-field text-sm" value={form.loanNumber} onChange={(e) => set('loanNumber', e.target.value)} />
            </Field>
            <Field label="Customer Name">
              <input className="input-field text-sm" value={form.customerName} onChange={(e) => set('customerName', e.target.value)} />
            </Field>
            <Field label="Branch Name">
              <input className="input-field text-sm" value={form.branchName} onChange={(e) => set('branchName', e.target.value)} />
            </Field>
            <Field label="Repo Date">
              <input type="date" className="input-field text-sm" value={form.repoDate} onChange={(e) => set('repoDate', e.target.value)} />
            </Field>
          </Section>

          <Section title="Vehicle Information">
            <Field label="Registration Number *">
              <input required className="input-field text-sm uppercase" value={form.registrationNumber} onChange={(e) => set('registrationNumber', e.target.value.toUpperCase())} />
            </Field>
            <Field label="Chassis Number *">
              <input required className="input-field text-sm uppercase" value={form.chassisNumber} onChange={(e) => set('chassisNumber', e.target.value.toUpperCase())} />
            </Field>
            <Field label="Engine Number *">
              <input required className="input-field text-sm uppercase" value={form.engineNumber} onChange={(e) => set('engineNumber', e.target.value.toUpperCase())} />
            </Field>
            <Field label="Vehicle Type *">
              <select required className="input-field text-sm" value={form.vehicleType} onChange={(e) => set('vehicleType', e.target.value)}>
                <option value="">Select Type</option>
                {vehicleTypes.map((t) => <option key={t} value={t}>{t}</option>)}
              </select>
            </Field>
            <Field label="Make">
              <input className="input-field text-sm" value={form.make} onChange={(e) => set('make', e.target.value)} />
            </Field>
            <Field label="Model">
              <input className="input-field text-sm" value={form.model} onChange={(e) => set('model', e.target.value)} />
            </Field>
            <Field label="Variant">
              <input className="input-field text-sm" value={form.variant} onChange={(e) => set('variant', e.target.value)} />
            </Field>
            <Field label="Fuel Type">
              <select className="input-field text-sm" value={form.fuelType} onChange={(e) => set('fuelType', e.target.value)}>
                <option value="">Select</option>
                {['Petrol', 'Diesel', 'CNG', 'Electric', 'Hybrid'].map((f) => <option key={f} value={f}>{f}</option>)}
              </select>
            </Field>
            <Field label="Transmission">
              <select className="input-field text-sm" value={form.transmissionType} onChange={(e) => set('transmissionType', e.target.value)}>
                <option value="">Select</option>
                {['Manual', 'Automatic', 'CVT', 'AMT'].map((t) => <option key={t} value={t}>{t}</option>)}
              </select>
            </Field>
            <Field label="Year">
              <input type="number" min="2000" max="2030" className="input-field text-sm" value={form.manufacturingYear} onChange={(e) => set('manufacturingYear', e.target.value)} />
            </Field>
            <Field label="Color">
              <input className="input-field text-sm" value={form.color} onChange={(e) => set('color', e.target.value)} />
            </Field>
          </Section>

          <Section title="Yard & Status">
            <Field label="Yard *">
              <select required className="input-field text-sm" value={form.yardId} onChange={(e) => set('yardId', e.target.value)}>
                <option value="">Select Yard</option>
                {yards.map((y) => <option key={y.id} value={y.id}>{y.name} — {y.city}</option>)}
              </select>
            </Field>
            <Field label="Running Status">
              <select className="input-field text-sm" value={form.runningStatus} onChange={(e) => set('runningStatus', e.target.value)}>
                {['Running', 'Red/Idle', 'Auctioned', 'Released', 'Sold', 'Scrap'].map((s) => (
                  <option key={s} value={s}>{s}</option>
                ))}
              </select>
            </Field>
            <Field label="Key Status">
              <select className="input-field text-sm" value={form.keyStatus} onChange={(e) => set('keyStatus', e.target.value)}>
                {['Yes', 'No', 'Duplicate Key', 'Missing'].map((s) => <option key={s} value={s}>{s}</option>)}
              </select>
            </Field>
            <Field label="RC Status">
              <select className="input-field text-sm" value={form.rcStatus} onChange={(e) => set('rcStatus', e.target.value)}>
                {['Submitted', 'Pending', 'Not Available', 'Duplicate'].map((s) => <option key={s} value={s}>{s}</option>)}
              </select>
            </Field>
            <Field label="Battery Condition">
              <select className="input-field text-sm" value={form.batteryCondition} onChange={(e) => set('batteryCondition', e.target.value)}>
                <option value="">N/A</option>
                {['Good', 'Fair', 'Poor', 'Dead'].map((s) => <option key={s} value={s}>{s}</option>)}
              </select>
            </Field>
            <Field label="Tyre Condition">
              <select className="input-field text-sm" value={form.tyreCondition} onChange={(e) => set('tyreCondition', e.target.value)}>
                <option value="">N/A</option>
                {['Good', 'Fair', 'Poor', 'Flat'].map((s) => <option key={s} value={s}>{s}</option>)}
              </select>
            </Field>
            <Field label="Odometer (km)">
              <input type="number" min="0" className="input-field text-sm" value={form.odometerReading} onChange={(e) => set('odometerReading', e.target.value)} />
            </Field>
            <Field label="Insurance Available">
              <div className="flex items-center gap-2 mt-2">
                <input type="checkbox" id="ins" checked={form.insuranceAvailable} onChange={(e) => set('insuranceAvailable', e.target.checked)} className="w-4 h-4" />
                <label htmlFor="ins" className="text-sm text-gray-700">Yes</label>
              </div>
            </Field>
          </Section>

          <Section title="Charges">
            <Field label="Parking Charges (₹)">
              <input type="number" min="0" className="input-field text-sm" value={form.parkingCharges} onChange={(e) => set('parkingCharges', e.target.value)} />
            </Field>
            <Field label="Towing Charges (₹)">
              <input type="number" min="0" className="input-field text-sm" value={form.towingCharges} onChange={(e) => set('towingCharges', e.target.value)} />
            </Field>
            <Field label="Misc Charges (₹)">
              <input type="number" min="0" className="input-field text-sm" value={form.miscCharges} onChange={(e) => set('miscCharges', e.target.value)} />
            </Field>
          </Section>

          <div className="flex justify-end gap-3">
            <button type="button" onClick={() => navigate('/inventory')} className="btn-secondary">
              Cancel
            </button>
            <button type="submit" disabled={submitting} className="btn-primary px-8 disabled:opacity-60">
              {submitting ? 'Saving...' : 'Save Entry'}
            </button>
          </div>
        </form>
      </div>
    </MainLayout>
  )
}
