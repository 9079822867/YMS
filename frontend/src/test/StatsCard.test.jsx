import { render, screen } from '@testing-library/react'
import { describe, it, expect } from 'vitest'
import StatsCard from '../components/common/StatsCard'

describe('StatsCard', () => {
  it('renders label and value', () => {
    render(<StatsCard label="Total Vehicles" value={1245} />)
    expect(screen.getByText('Total Vehicles')).toBeInTheDocument()
    expect(screen.getByText('1,245')).toBeInTheDocument()
  })

  it('renders dash when value is undefined', () => {
    render(<StatsCard label="Loading" value={undefined} />)
    expect(screen.getByText('—')).toBeInTheDocument()
  })

  it('applies color class', () => {
    render(<StatsCard label="Running" value={845} color="text-green-600" />)
    const valueEl = screen.getByText('845')
    expect(valueEl).toHaveClass('text-green-600')
  })
})
