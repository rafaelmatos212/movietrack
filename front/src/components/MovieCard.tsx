export default function MovieCard() {
  return (
    <div className="max-w-[256px] w-full bg-white dark:bg-gray-800 rounded-lg shadow-lg">
      <h2 className="text-sm font-bold text-center text-gray-700 dark:text-gray-300 p-2 h-14 overflow-hidden flex items-center justify-center">
        O Dragão da Maldade Contra o Santo Guerreiroasasdasd
      </h2>
      <img
        className="w-full object-cover aspect-[2/3]"
        src="https://media.themoviedb.org/t/p/w300_and_h450_bestv2/1F9XXHadJR2as6YAi9hkG6bkDEE.jpg"
        alt="Movie Poster"
      />
      <div className="flex justify-between p-4">
        <span className="text-sm text-gray-500 dark:text-gray-400">Release Date: 2023</span>
        <span className="text-sm text-gray-500 dark:text-gray-400">Rating: ★★★★☆</span>
      </div>
    </div>
  )
}