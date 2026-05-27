import axios from 'axios'

const api = axios.create({ baseURL: '/api' })

api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token')
  if (token) config.headers.Authorization = `Bearer ${token}`
  return config
})

api.interceptors.response.use(
  (res) => res,
  (err) => {
    if (err.response?.status === 401) {
      localStorage.removeItem('token')
      localStorage.removeItem('user')
      window.location.href = '/'
    }
    return Promise.reject(err)
  }
)

export const authApi = {
  login: (data) => api.post('/auth/login', data),
  register: (data) => api.post('/auth/register', data),
}

export const inventoryApi = {
  search: (params) => api.get('/inventory', { params }),
  getById: (id) => api.get(`/inventory/${id}`),
  create: (data) => api.post('/inventory', data),
  updateStatus: (id, data) => api.patch(`/inventory/${id}/status`, data),
  delete: (id) => api.delete(`/inventory/${id}`),
}

export const dashboardApi = {
  getStats: () => api.get('/dashboard/stats'),
}

export const mastersApi = {
  getClients: () => api.get('/masters/clients'),
  getYards: () => api.get('/masters/yards'),
  getStates: () => api.get('/masters/states'),
  getVehicleTypes: () => api.get('/masters/vehicle-types'),
  getRunningStatuses: () => api.get('/masters/running-statuses'),
}

export default api
