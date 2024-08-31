using Airline.Domain.Interfaces;
using AirlineWeb.Extensions;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.User;

namespace AirlineWeb.Stores;

public class UserStore : IUserStore
{
    private readonly ICommonRepository _repository;

    public UserStore(ICommonRepository repository)
    {
        _repository = repository?? throw new ArgumentNullException(nameof(repository));
    }
    
    public List<UserView> GetAll(string? search)
    {
        var entities = _repository.Users.GetAll(search);
        var viewModels = entities
            .Select(x => x.ToView())
            .ToList();

        return viewModels;
    }

    public UserView GetById(int id)
    {
        var entity = _repository.Users.GetById(id);

        return entity.ToView();
    }

    public UpdateUserView GetForUpdate(int id)
    {
        var user = _repository.Users.GetById(id);
        var viewModel = user.ToUpdateView();

        return viewModel;
    }

    public UserView Create(CreateUserView userView)
    {
        ArgumentNullException.ThrowIfNull(userView);

        var entity = userView.ToEntity();

        var createdUser = _repository.Users.Create(entity);
        _repository.SaveChanges();
        
        var viewModel = createdUser.ToView();

        return viewModel;
    }

    public void Update(UpdateUserView userView)
    {
        ArgumentNullException.ThrowIfNull(userView);

        var entity = userView.ToEntity();

        _repository.Users.Update(entity);
        _repository.SaveChanges();
    }

    public void Delete(int id)
    {
        _repository.Users.Delete(id);
        _repository.SaveChanges();    }
}