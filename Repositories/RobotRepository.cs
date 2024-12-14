using Microsoft.EntityFrameworkCore;
using robot_generator.Data;
using robot_generator.Exceptions;
using robot_generator.Models;
using robot_generator.Repositories.Interfaces;

namespace robot_generator.Repositories;

public class RobotRepository : BaseRepository<RobotDbContext, Robot>
{

    public override Robot GetById(string id)
    {
        var robot = Context.Robots.FirstOrDefault(robot => robot.RobotId == id);

        if (robot == null) throw new DatabaseEntityNotFoundException();
        
        return robot;
    }

    public override IEnumerable<Robot> GetAll()
    {
        return Context.Robots.ToList();
    }

    public override void Add(Robot entity)
    {
        Context.Robots.Add(entity);
    }

    public override void Update(Robot entity)
    {
        Context.Robots.Update(entity);
    }

    public override void Delete(Robot entity)
    {
        Context.Robots.Remove(entity);
    }
}