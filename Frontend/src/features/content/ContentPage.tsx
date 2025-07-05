import { useEffect, useState } from "react";
import type { ContentDto, ContentType } from "../../types/content";
import { getContentByTypePaginated, searchContent } from "../../api/contentApi";
import ContentCard from "../../components/ContentCard";
import Search from "../../components/Search";
import ToggleSwitch from "../../components/ToggleSwitch";
import Pagination from "../../components/Pagination";

const ContentPage = () => {
  const [content, setContent] = useState<ContentDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [page, setPage] = useState<number>(1);
  const [pageSize] = useState<number>(10);
  const [type, setType] = useState<ContentType>("Movie");
  const [searchTitle, setSearchTitle] = useState<string | undefined>();
  const [searchDate, setSearchDate] = useState<string | undefined>();

  useEffect(() => {
    const isSearching = (searchTitle && searchTitle.length >= 2) || searchDate;

    setLoading(true);

    if (isSearching) {
      searchContent(searchTitle, searchDate)
        .then((data) => setContent(data))
        .catch(console.error)
        .finally(() => setLoading(false));
    } else {
      getContentByTypePaginated(type, page, pageSize)
        .then((newData) => {
          setContent((prev) => (page === 1 ? newData : [...prev, ...newData]));
        })
        .catch(console.error)
        .finally(() => setLoading(false));
    }
  }, [searchTitle, searchDate, page, type]);

  const loadMore = () => {
    setPage((prev) => prev + 1);
  };

  const Switch = (newType: ContentType) => {
    if (newType !== type) {
      setPage(1);
      setContent([]);
      setType(newType);
    }
  };

  return (
    <div>
      <div>
        <Search
          onSearchChange={(title, date) => {
            setSearchTitle(title);
            setSearchDate(date);
          }}
        />
      </div>

      <div>
        <ToggleSwitch onTypeChange={Switch} />
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
