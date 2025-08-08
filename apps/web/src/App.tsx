import './App.css'

export default function App() {
  return (
    <div className="min-h-screen bg-gradient-to-b from-slate-950 to-slate-900 text-slate-100">
      <div className="mx-auto max-w-3xl px-6 py-16">
        <header className="mb-10">
          <h1 className="text-3xl font-semibold">HireReady.ai</h1>
          <p className="text-slate-400 mt-2">Adaptive, fair first‑round interviews</p>
        </header>
        <div className="grid gap-6">
          <a href="/recruiter/job" className="rounded-lg border border-slate-800 bg-slate-900/60 p-6 hover:bg-slate-900">
            <h2 className="text-xl font-medium">Recruiter</h2>
            <p className="text-slate-400">Define jobs, generate interviews, and review results.</p>
          </a>
          <a href="/candidate/pin" className="rounded-lg border border-slate-800 bg-slate-900/60 p-6 hover:bg-slate-900">
            <h2 className="text-xl font-medium">Candidate</h2>
            <p className="text-slate-400">Enter PIN to start your interview.</p>
          </a>
        </div>
      </div>
    </div>
  )
}
