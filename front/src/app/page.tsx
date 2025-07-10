import MovieCard from "@/components/MovieCard";

export default function Home() {
  return (
    <div className="bg-gray-500 mx-auto p-4 grid grid-cols-[repeat(auto-fit,minmax(200px,1fr))] gap-6 justify-items-center">
      <MovieCard />
      <MovieCard />
      <MovieCard />
      <MovieCard />
      <MovieCard />
      <MovieCard />
      <MovieCard />
      <MovieCard />
      <MovieCard />
    </div>
  );
}
