import Link from "next/link";

export default function Navbar() {
  return (
    <nav className="fixed top-0 left-0 w-full z-50 bg-gray-900 text-white p-4 shadow-md">
      <div className="max-w-6xl mx-auto flex justify-between items-center">
        <Link href="/" className="text-xl font-bold cursor-pointer">MovieTrack</Link>
        <div className="flex gap-4">
          <Link href="/">Início</Link>
          <Link href="/favoritos">Favoritos</Link>
          <Link href="/login">Login</Link>
        </div>
      </div>
    </nav>

  )
}