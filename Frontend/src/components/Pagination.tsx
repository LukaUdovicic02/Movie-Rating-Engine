type Props = {
  onLoadMore: () => void;
};

function Pagination({ onLoadMore }: Props) {
  return (
    <div className="flex justify-center mt-8 mb-8">
      <button
        onClick={onLoadMore}
        className="bg-gray-300 px-4 py-1.5 rounded-md
         shadow-lg hover:bg-gray-200 border border-gray-100 transition duration-500"
      >
        View More Results
      </button>
    </div>
  );
}

export default Pagination;
