import { use, useEffect, useState } from "react";
import type { ContentDto } from "../../types/content";
import { getContentByTypePaginated } from "../../api/contentApi";
import ContentCard from "../../components/ContentCard";
import Search from "../../components/Search";
import ToggleSwitch from "../../components/ToggleSwitch";
import Pagination from "../../components/Pagination";

const ContentPage = () => {
  const [content, setContent] = useState<ContentDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [page, setPage] = useState<number>(1);
  const [pageSize] = useState<number>(10);

  useEffect(() => {
    setLoading(true);
    getContentByTypePaginated("Movie", page, pageSize)
      .then((newData) => {
        if (content.length === 0) setContent(newData);
        else setContent((prev) => [...prev, ...newData]);
      })
      .catch(console.error)
      .finally(() => setLoading(false));
  }, [page]);

  const loadMore = () => {
    setPage((prev) => prev + 1);
  };

  console.log(content.length);

  return (
    <div>
      <div>
        <Search />
      </div>

      <div>
        <ToggleSwitch />
      </div>

      <div className="flex justify-center flex-wrap gap-12 mt-8 ">
        {loading ? (
          <p>Loading ...</p>
        ) : (
          content.map((item) => <ContentCard key={item.id} content={item} />)
        )}
      </div>

      <div>
        <Pagination onLoadMore={loadMore} />
      </div>
    </div>
  );
};

export default ContentPage;
