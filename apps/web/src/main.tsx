import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import './index.css'
import App from './App'

function RecruiterJobForm() {
  return (
    <div className="min-h-screen bg-slate-950 text-slate-100 p-6">
      <h1 className="text-2xl font-semibold mb-4">Create Job</h1>
      <form className="grid gap-4 max-w-xl">
        <input className="bg-slate-900 border border-slate-800 rounded px-3 py-2" placeholder="Job title" />
        <textarea className="bg-slate-900 border border-slate-800 rounded px-3 py-2" placeholder="Responsibilities" rows={4} />
        <textarea className="bg-slate-900 border border-slate-800 rounded px-3 py-2" placeholder="Must haves" rows={3} />
        <button className="bg-indigo-600 hover:bg-indigo-500 rounded px-4 py-2 w-fit">Save</button>
      </form>
    </div>
  )
}

function CandidatePin() {
  return (
    <div className="min-h-screen bg-slate-950 text-slate-100 p-6">
      <h1 className="text-2xl font-semibold mb-4">Enter PIN</h1>
      <form className="grid gap-4 max-w-sm">
        <input className="bg-slate-900 border border-slate-800 rounded px-3 py-2" placeholder="PIN" />
        <button className="bg-indigo-600 hover:bg-indigo-500 rounded px-4 py-2 w-fit">Start</button>
      </form>
    </div>
  )
}

const router = createBrowserRouter([
  { path: '/', element: <App /> },
  { path: '/recruiter/job', element: <RecruiterJobForm /> },
  { path: '/candidate/pin', element: <CandidatePin /> },
])

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
