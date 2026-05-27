import { render, screen } from '@testing-library/react'
import { describe, it, expect } from 'vitest'
import { RunningBadge, KeyBadge, RcBadge } from '../components/common/StatusBadge'

describe('RunningBadge', () => {
  it('renders Running with green class', () => {
    render(<RunningBadge status="Running" />)
    const el = screen.getByText('Running')
    expect(el).toBeInTheDocument()
    expect(el).toHaveClass('bg-green-600')
  })

  it('renders Red/Idle with red class', () => {
    render(<RunningBadge status="Red/Idle" />)
    expect(screen.getByText('Red/Idle')).toHaveClass('bg-red-600')
  })

  it('renders unknown status with gray fallback', () => {
    render(<RunningBadge status="Unknown" />)
    expect(screen.getByText('Unknown')).toHaveClass('bg-gray-400')
  })
})

describe('KeyBadge', () => {
  it('renders Yes with yellow', () => {
    render(<KeyBadge status="Yes" />)
    expect(screen.getByText('Yes')).toHaveClass('bg-yellow-500')
  })

  it('renders No with orange', () => {
    render(<KeyBadge status="No" />)
    expect(screen.getByText('No')).toHaveClass('bg-orange-500')
  })
})

describe('RcBadge', () => {
  it('renders Submitted with blue', () => {
    render(<RcBadge status="Submitted" />)
    expect(screen.getByText('Submitted')).toHaveClass('bg-blue-600')
  })

  it('renders Pending with gray', () => {
    render(<RcBadge status="Pending" />)
    expect(screen.getByText('Pending')).toHaveClass('bg-gray-400')
  })
})
